using AutoMapper;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Contracts.List.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelApp.Interfaces;
using System.IO;

public class ListService : IListService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ListService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List> CreateListAsync(ListCreateDTO listCreateDTO)
    {
        string filePath = null;

        if (listCreateDTO.Slika != null)
        {
            // Generisanje jedinstvenog naziva fajla
            var fileName = Path.GetFileNameWithoutExtension(listCreateDTO.Slika.FileName);
            var extension = Path.GetExtension(listCreateDTO.Slika.FileName);
            fileName = $"{fileName}_{Guid.NewGuid()}{extension}";

            // Definisanje putanje do foldera gde će se slike čuvati
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await listCreateDTO.Slika.CopyToAsync(stream);
            }

            filePath = $"/images/{fileName}"; // Čuvanje relativne putanje
        }

        var list = _mapper.Map<List>(listCreateDTO);
        list.Slika = filePath; // Čuvanje putanje umesto fajla

        _context.Lists.Add(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<List> GetListByIdAsync(int id)
    {
        var list = await _context.Lists.FindAsync(id);
        if (list == null)
        {
            throw new KeyNotFoundException("Lista nije pronađena.");
        }
        return list;
    }

    public async Task<IEnumerable<List>> GetAllListsAsync()
    {
        return await _context.Lists.ToListAsync();
    }

    public async Task UpdateListAsync(int id, ListUpdateDTO listUpdateDTO)
    {
        var list = await _context.Lists.FindAsync(id);
        if (list == null)
        {
            throw new KeyNotFoundException("Lista nije pronađena.");
        }

        _mapper.Map(listUpdateDTO, list);

        _context.Entry(list).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteListAsync(int id)
    {
        var list = await _context.Lists.FindAsync(id);
        if (list == null)
        {
            throw new KeyNotFoundException("Lista nije pronađena.");
        }

        _context.Lists.Remove(list);
        await _context.SaveChangesAsync();
    }
}
