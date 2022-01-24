using AutoMapper;
using ClosedXML.Excel;
using Curatio.Data;
using Curatio.Models.Form3;
using Curatio.Repository;
using Curatio.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Curatio.Controllers
{
    public class Form3Controller : Controller
    {
        #region DependencyInjection

        private readonly AppDbContext _context;
        private readonly IFormThree _formThreeRepo;
        private readonly IMapper _mapper;

        public Form3Controller(
            AppDbContext context,
            IFormThree formThreeRepo,
            IMapper mapper
            )
        {
            _context = context;
            _formThreeRepo = formThreeRepo;
            _mapper = mapper;
        }
        #endregion

        #region GetFormThrees
        [HttpGet]
        public ViewResult Form3List(FilterForm3 body)
        {
            var allForm3s = _formThreeRepo.GetAllForm3s();

            if (body == null)
            {
                return View(new Form3ListViewModel { Form3s = allForm3s });

            }
            else
            {
                var filtered = _formThreeRepo.FilteredForm3s(body);
                return View(new Form3ListViewModel { Form3s = filtered });
            }
        }
        #endregion

        #region FormThreeDetails

        public IActionResult Form3Details(int id)
        {
            var details = _context.FormThree.FirstOrDefault(d => d.Id == id);
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }
        #endregion

        #region AddFormThree
        public IActionResult Form3Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Form3ForCreation body)
        {
            var formThreeEntity = _mapper.Map<Form3>(body);
            _formThreeRepo.CreateFormThree(formThreeEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction("Form3List");
        }
        #endregion

        #region UpdateFormThree
        public IActionResult Form3Edit(int id)
        {
            var info = _context.FormThree.FirstOrDefault(d => d.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Form3ForUpdate body)
        {
            var formThreeEntity = _mapper.Map<Form3>(body);
            formThreeEntity.Id = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getFormById = _context.FormThree.Any(d => d.Id == formThreeEntity.Id);
            if (!getFormById)
            {
                return BadRequest();
            }

            _formThreeRepo.UpdateFormThree(formThreeEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction("Form3List");
        }
        #endregion

        #region DeleteFormThree
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var body = await _context.FormThree.FindAsync(id);
            if (body == null)
            {
                return NotFound();
            }

            _context.FormThree.Remove(body);
            await _context.SaveChangesAsync();

            return RedirectToAction("Form3List");
        }
        #endregion

        #region ExportToExcel

        public IActionResult ExportToExcel()
        {
            var allforms = _context.FormThree;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Company";
                worksheet.Cell(currentRow, 3).Value = "DoctorName";
                worksheet.Cell(currentRow, 4).Value = "DoctorEmail";
                worksheet.Cell(currentRow, 5).Value = "DoctorPhone";
                worksheet.Cell(currentRow, 6).Value = "Date";
                worksheet.Cell(currentRow, 7).Value = "FullName";
                worksheet.Cell(currentRow, 8).Value = "Address";
                worksheet.Cell(currentRow, 9).Value = "Province";
                worksheet.Cell(currentRow, 10).Value = "Email";
                worksheet.Cell(currentRow, 11).Value = "Phone";
                worksheet.Cell(currentRow, 12).Value = "PrivateId";
                worksheet.Cell(currentRow, 13).Value = "Researches";
                worksheet.Cell(currentRow, 14).Value = "Transport";
                worksheet.Cell(currentRow, 15).Value = "Comment";

                foreach (var form in allforms)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = form.Id;
                    worksheet.Cell(currentRow, 2).Value = form.Company;
                    worksheet.Cell(currentRow, 3).Value = form.DoctorName;
                    worksheet.Cell(currentRow, 4).Value = form.DoctorEmail;
                    worksheet.Cell(currentRow, 5).Value = form.DoctorPhone;
                    worksheet.Cell(currentRow, 6).Value = form.Date;
                    worksheet.Cell(currentRow, 7).Value = form.FullName;
                    worksheet.Cell(currentRow, 8).Value = form.Address;
                    worksheet.Cell(currentRow, 9).Value = form.Province;
                    worksheet.Cell(currentRow, 10).Value = form.Email;
                    worksheet.Cell(currentRow, 11).Value = form.Phone;
                    worksheet.Cell(currentRow, 12).Value = form.PrivateId;
                    worksheet.Cell(currentRow, 13).Value = form.Researches;
                    worksheet.Cell(currentRow, 14).Value = form.Transport;
                    worksheet.Cell(currentRow, 15).Value = form.Comment;

                    worksheet.Cell(currentRow, 13).Style.Font.FontSize = 9;
                    worksheet.Cell(currentRow, 15).Style.Font.FontSize = 9;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "users.xlsx");
                }

            }
        }
        #endregion
    }
}
