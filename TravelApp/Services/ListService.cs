using AutoMapper;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Contracts.List.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelApp.Interfaces;

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
        var list = _mapper.Map<List>(listCreateDTO);
        _context.Lists.Add(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<List> GetListByIdAsync(int id)
    {
        return await _context.Lists.FindAsync(id);
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
            throw new KeyNotFoundException();
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
            throw new KeyNotFoundException();
        }

        _context.Lists.Remove(list);
        await _context.SaveChangesAsync();
    }
}
