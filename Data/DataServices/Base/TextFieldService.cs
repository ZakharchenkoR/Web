using Data.DataServices.IDataServices;
using Data.Domain;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataServices.Base
{
    public class TextFieldService : ITextFieldRepository
    {
        private readonly AppDbContext _appDbContext;

        public TextFieldService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> DeleteTextField(TextField[] entities)
        {
            _appDbContext.TextFields.RemoveRange(entities);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<TextField> GetTextFieldAsync(Guid id)
        {
            return await _appDbContext.TextFields.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TextField> GetTextFieldAsync(string codeWord)
        {
            return await _appDbContext.TextFields.FirstOrDefaultAsync(x => x.CodeWord == codeWord);

        }

        public async Task<IList<TextField>> GetTextFieldsAsync()
        {
            var items = await GetTextFieldQuery().AsNoTracking().ToListAsync();
            return items;
        }

        private IQueryable<TextField> GetTextFieldQuery()
        {
            IQueryable<TextField> items = _appDbContext.TextFields;
            return items;
        }
    }
}
