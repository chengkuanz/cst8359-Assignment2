﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Lab5.Models.ViewModels;
using Azure.Storage.Blobs;
using Azure;





namespace Lab5.Controllers
{
    public class NewsController : Controller
    {
        private readonly SportsDbContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private const string containerName = "newsimage"; // Azure Blob container name

        public NewsController(SportsDbContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        // GET: News
        public async Task<IActionResult> Index(string id)
        {
            var sportClub = _context.SportClubs.Find(id);
            if (sportClub == null)
            {
                return NotFound();
            }

            var news = _context.News.Where(n => n.SportClubId == id).ToList();
            var viewModel = new NewsViewModel
            {
                SportClub = sportClub,
                News = news
            };

            return View(viewModel);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Fetch the SportClub object
            var sportClub = _context.SportClubs.Find(id);
            if (sportClub == null)
            {
                return NotFound();
            }

            // Initialize the News model with the SportClub information
            var news = new News
            {
                SportClubId = id,
                SportClub = sportClub
            };

            // Pass the fully initialized model to the view
            return View(news);
        }


        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("SportClubId")] News news)
        {
            var containerClient = await GetOrCreateContainerClientAsync();
            if (containerClient == null)
            {
                return View("Error");
            }

            var randomFileName = Path.GetRandomFileName();
            var blockBlob = containerClient.GetBlobClient(randomFileName);

            try
            {
                await UploadFileToBlobAsync(file, blockBlob);
                //for db
               // news.FileName = file.FileName;
               news.FileName = randomFileName;
                news.Url = blockBlob.Uri.ToString();
                _context.Add(news);
                await _context.SaveChangesAsync();
            }
            catch (RequestFailedException)
            {
                return View("Error");
            }

            return RedirectToAction(nameof(Index), new { id = news.SportClubId });
        }


        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.SportClub) // Ensure SportClub is included
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            var viewModel = new NewsViewModel
            {
                News = new List<News> { news },
                SportClub = news.SportClub // Set the SportClub in the ViewModel
            };

            return View(viewModel);
        }


        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index), new { id = news.SportClubId });
        }


        private async Task<BlobContainerClient> GetOrCreateContainerClientAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            if (await containerClient.ExistsAsync())
            {
                return containerClient;
            }
            else
            {
                containerClient = await _blobServiceClient.CreateBlobContainerAsync(containerName, Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
                return containerClient;
            }
        }

        private async Task UploadFileToBlobAsync(IFormFile file, BlobClient blobClient)
        {
            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream);
            }
        }

        private async Task DeleteAllBlobsAsync(BlobContainerClient containerClient)
        {
            await foreach (var blob in containerClient.GetBlobsAsync())
            {
                var blobClient = containerClient.GetBlobClient(blob.Name);
                if (await blobClient.ExistsAsync())
                {
                    await blobClient.DeleteAsync();
                }
            }
        }
    }
}