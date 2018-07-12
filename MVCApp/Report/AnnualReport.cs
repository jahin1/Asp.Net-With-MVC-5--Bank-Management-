using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRepository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



namespace MVCApp.Report
{
    public class AnnualReport
    {
        #region
        int _totalColumn = 5;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(5);
        PdfPCell _pdfpCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Transaction> _student = new List<Transaction>();

        #endregion
        public byte[] PrepareReport(List<Transaction> students)
        {

            _students = students;

            #region

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 30f,30f,30f,30f,30f });
            #endregion
            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();


        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfpCell = new PdfPCell(new Phrase("ABC Bank LTD.", _fontStyle));
            _pdfpCell.Colspan = _totalColumn;
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.Border = 0;
            _pdfpCell.BackgroundColor = BaseColor.YELLOW;
            _pdfpCell.ExtraParagraphSpace = 1;
            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Annual Transactions Reports", _fontStyle));
            _pdfpCell.Colspan = _totalColumn;
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.Border = 0;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfpCell.ExtraParagraphSpace = 1;
            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();




        }

        private void ReportBody()
        {

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Transaction Date", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdfTable.AddCell(_pdfpCell);

            _pdfpCell = new PdfPCell(new Phrase("Account Name", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.GRAY;

            _pdfTable.AddCell(_pdfpCell);


            _pdfpCell = new PdfPCell(new Phrase("Branch Name", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdfTable.AddCell(_pdfpCell);



            _pdfpCell = new PdfPCell(new Phrase("Referance of Transaction", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.GRAY;

            _pdfTable.AddCell(_pdfpCell);

            _pdfpCell = new PdfPCell(new Phrase("Transaction Amount", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;//Element.ALIGN_CENTER; Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();


            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (Transaction student in _students)
            {
                _pdfpCell = new PdfPCell(new Phrase(student.Tr_Date, _fontStyle));

                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;//ALIGN_MIDDLE;ALIGN_CENTER
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;

                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(student.Tr_AccName, _fontStyle));

                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;

                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(student.Tr_Branch, _fontStyle));
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(student.Tr_Through, _fontStyle));

                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;

                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase((student.Tr_Amount).ToString(), _fontStyle));

                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;

                _pdfTable.AddCell(_pdfpCell);
                _pdfTable.CompleteRow();


            }

            #endregion


        }




        public Rectangle pageSize { get; set; }

        public List<Transaction> _students { get; set; }

        internal byte[] PrepareReport()
        {
            throw new NotImplementedException();
        }
    }
}

