using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp_Project.Models;

namespace iTextSharp_Project.Report
{
    public class StudentReport
    {
        #region
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfpCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Student> _student = new List<Student>();

#endregion
        public byte[] PrepareReport(List<Student>students)
        {

            _students = students;

            #region

            _document = new Document(PageSize.A4,0f,0f,0f,0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f,20f,20f,20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma",8f,1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f });
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
            _pdfpCell = new PdfPCell(new Phrase("My Project Report",_fontStyle));
            _pdfpCell.Colspan = _totalColumn;
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.Border = 0;
            _pdfpCell.BackgroundColor = BaseColor.WHITE;
            _pdfpCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Student List", _fontStyle));
            _pdfpCell.Colspan = _totalColumn;
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.Border = 0;
            _pdfpCell.BackgroundColor = BaseColor.WHITE;
            _pdfpCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();




        }

        private void ReportBody()
        {
          
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Serial Number", _fontStyle));
            
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            
            _pdfTable.AddCell(_pdfpCell);
           
           
            _pdfpCell = new PdfPCell(new Phrase("Name", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            
            _pdfTable.AddCell(_pdfpCell);
             
            _pdfpCell = new PdfPCell(new Phrase("Roll", _fontStyle));

            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;//Element.ALIGN_CENTER; Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            
            _pdfTable.AddCell(_pdfpCell);
            _pdfTable.CompleteRow();
            

            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma",8f,0);
            int serialNumber = 1;
            foreach (Student student in _students)
            {
                _pdfpCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;//ALIGN_MIDDLE;ALIGN_CENTER
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;
                
                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(student.Name, _fontStyle));
                
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;
                
                _pdfTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(student.Roll, _fontStyle));               
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.WHITE;          
                _pdfTable.AddCell(_pdfpCell);

                _pdfTable.CompleteRow();
            
            
            }

            #endregion


        }




        public Rectangle pageSize { get; set; }

        public List<Student> _students { get; set; }

        internal byte[] PrepareReport()
        {
            throw new NotImplementedException();
        }
    }
}