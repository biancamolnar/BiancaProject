using BiancaProject.Contexts;
using BiancaProject.Models.Entities;
using BiancaProject.Models.Forms;
using Microsoft.EntityFrameworkCore;


namespace BiancaProject.Services
{
    internal class CommentService
    {
        private readonly DataContext _context = new DataContext();

        //registrate a new comment
        public async Task<CommentEntity> CreateAsync(string caseId, CommentForm form)
        {
            var commentEntity = new CommentEntity()
            {
                CaseId = caseId,
                CommentText = form.CommentText,
                TimeWritten = DateTime.Now,
            };

            _context.Add(commentEntity);
            await _context.SaveChangesAsync();

            return commentEntity;
        }
    }
}
