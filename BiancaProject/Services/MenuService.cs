using BiancaProject.Migrations;
using BiancaProject.Models.Entities;
using BiancaProject.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace BiancaProject.Services
{
    internal class MenuService
    {
        private readonly CaseService _caseService = new CaseService();
        private readonly CommentService _commentService = new CommentService();
        private readonly StatusService _statusService = new StatusService();

        public async Task MainMenu()
        {
            Console.Clear();
            Console.WriteLine("####### HUVUDMENY #######");
            Console.WriteLine("1. Skapa nytt ärende");
            Console.WriteLine("2. Visa alla ärenden");
            Console.WriteLine("3. Visa specifikt ärende");
            Console.WriteLine("4. Skriv kommentar till ett specifikt ärende");
            Console.Write("\nAnge ett av följande alternativ (1-4): ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateMenu();
                    break;

                case "2":
                    await ShowAllMenu();
                    break;

                case "3":
                    await ShowSpecificMenu();
                    break;
                case "4":
                    await WriteCommentMenu();
                    break;
                case "5":
                    await ChangeStatusMenu();
                    break;
            }

            Console.ReadKey();
        }

        public async Task CreateMenu()
        {
            var form = new CaseRegistrationForm();

            Console.Clear();
            Console.WriteLine("####### SKAPA NYTT ÄRENDE #######");
            Console.Write("Förnamn: "); form.FirstName = Console.ReadLine() ?? "";
            Console.Write("Efternamn: "); form.LastName = Console.ReadLine() ?? "";
            Console.Write("Telefonnummer: "); form.PhoneNumber = Console.ReadLine() ?? "";
            Console.Write("E-mail: "); form.Email = Console.ReadLine() ?? "";
            Console.Write("Beskrivning: "); form.Description = Console.ReadLine() ?? "";

            var result = await _caseService.CreateAsync(form);
            Console.WriteLine($"\nÄrendet med ärendenummer {result.CaseId} har skapats");
        }

        public async Task ShowAllMenu()
        {
            Console.Clear();
            Console.WriteLine("####### VISA ALLA ÄRENDEN #######");
            foreach (var registratedCase in await _caseService.GetAllAsync())
                Console.WriteLine($"{registratedCase.CaseId}, {registratedCase.Description} {registratedCase.Tenant.FirstName}");

        }

        public async Task ShowSpecificMenu()
        {
            await ShowAllMenu();

            Console.Write("Ange ärendenummer: ");
            var caseId = Console.ReadLine();

            if (!string.IsNullOrEmpty(caseId))
            {
                var registratedCase = await _caseService.GetAsync(caseId);
                if (registratedCase != null)
                {
                    Console.Clear();
                    Console.WriteLine("####### ÄRENDEINFORMATION #######");
                    Console.WriteLine($"Ärendenummer: {registratedCase.CaseId}");
                    Console.WriteLine($"Beskrivning: {registratedCase.Description}");
                    Console.WriteLine($"Registrerat: {registratedCase.TimeWritten}");
                    Console.WriteLine($"Status: {registratedCase.Status.StatusName}");
                    Console.WriteLine($"Förnamn: {registratedCase.Tenant.FirstName}");
                    Console.WriteLine($"Efternamn: {registratedCase.Tenant.LastName}");
                    Console.WriteLine($"Telefonnummer: {registratedCase.Tenant.PhoneNumber}");
                    Console.WriteLine($"Email: {registratedCase.Tenant.Email}");
                    Console.WriteLine("Kommentarer:");

                    foreach (var comment in registratedCase.Commments)
                    {
                        Console.WriteLine($"- {comment.CommentText} ({comment.TimeWritten})");
                    }
                }
                else
                {
                    Console.WriteLine($"Inget ärende med ärendenummer {caseId} hittades");
                }
            }
            else
            {
                Console.WriteLine("Inget ärendenummer specificerades");
            }
        }

        public async Task WriteCommentMenu()
        {
            await ShowAllMenu();

            Console.Write("Ange ärendenummer: ");
            var caseId = Console.ReadLine();

            if (!string.IsNullOrEmpty(caseId))
            {
                var form = new CommentForm();

                Console.WriteLine("####### SKRIV KOMMENTAR #######");
                Console.Write("Kommentar: ");
                form.CommentText = Console.ReadLine() ?? "";

                if (form != null && caseId != null)
                {
                    var result = await _commentService.CreateAsync(caseId.ToString(), form);
                    Console.WriteLine($"\nKommentaren har lagts till i ärende med ärendenummer {result.CaseId}");
                }
                else
                {
                    Console.WriteLine("Kommentaren kunde inte läggas till. Antingen är formuläret tomt eller ärendenummer saknas.");
                }
            }
        }

        public async Task ChangeStatusMenu()
        {
            
        }

    }

    }

