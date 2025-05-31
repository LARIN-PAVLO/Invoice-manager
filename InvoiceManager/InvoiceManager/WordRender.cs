using System;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace InvoiceManager
{
    internal class WordRender
    {
        private FileInfo _fileInfo;

        public WordRender(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new Exception("Файл не знайдений!");
            }
        }

        internal bool Process(Dictionary<string, string> items, List<Dictionary<string, string>> products = null)
        {
            Word.Application app = null;

            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                // Заміна маркерів тексту в документі
                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }

                // Якщо є продукти, додамо їх до таблиці
                if (products != null && products.Count > 0)
                {
                    Word.Document doc = app.ActiveDocument;

                    if (doc.Tables.Count >= 2)
                    {
                        // Отримуємо другу таблицю
                        Word.Table table = doc.Tables[2];

                        // Шукаємо перший рядок, де є маркери
                        Word.Row targetRow = null;
                        foreach (Word.Row row in table.Rows)
                        {
                            foreach (Word.Cell cell in row.Cells)
                            {
                                if (cell.Range.Text.Contains("<NameProduct>"))
                                {
                                    targetRow = row;
                                    break;
                                }
                            }
                            if (targetRow != null)
                                break;
                        }

                        if (targetRow != null)
                        {
                            Word.Row lastInsertedRow = targetRow;

                            for (int j = products.Count - 1; j >= 0; j--)
                            {
                                var product = products[j];
                                Word.Row rowToUse;

                                if (j == products.Count - 1)
                                {
                                    // Використовуємо targetRow для першого продукту
                                    rowToUse = targetRow;
                                }
                                else
                                {
                                    object afterRow = lastInsertedRow.Range;
                                    rowToUse = table.Rows.Add(ref afterRow);
                                }

                                int cellIndex = 1;
                                foreach (Word.Cell cell in rowToUse.Cells)
                                {
                                    string marker = string.Empty;

                                    switch (cellIndex)
                                    {
                                        case 1:
                                            marker = (j + 1).ToString();
                                            break;
                                        case 2:
                                            marker = "<NameProduct>";
                                            break;
                                        case 3:
                                            marker = "<Amount>";
                                            break;
                                        case 4:
                                            marker = "<UnitName>";
                                            break;
                                        case 5:
                                            marker = "<UnitPrice>";
                                            break;
                                        case 6:
                                            marker = "<SumProdact>";
                                            break;
                                    }

                                    cell.Range.Text = product.ContainsKey(marker) ? product[marker] : marker;
                                    cellIndex++;
                                }

                                lastInsertedRow = rowToUse; // Пам’ятаємо, куди вставили останній
                            }
                        }

                        else
                        {
                            throw new Exception("Не знайдено рядок з маркерами в таблиці.");
                        }
                    }
                    else
                    {
                        throw new Exception("Не знайдено таблицю 2 в документі.");
                    }
                }

                // Запитуємо користувача, куди зберегти файл
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Зберегти документ як...";
                    saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_fileInfo.Name) + "(1)";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Object newFileName = saveFileDialog.FileName;
                        app.ActiveDocument.SaveAs2(newFileName);
                        app.ActiveDocument.Close();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Збереження скасовано користувачем.");
                        app.ActiveDocument.Close(false);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
                MessageBox.Show("Помилка: " + ex.Message, "Заголовок");
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }

            return false;
        }
    }
}
