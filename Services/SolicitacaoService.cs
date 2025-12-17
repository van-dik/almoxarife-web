using Microsoft.EntityFrameworkCore;
using SistemaAlmoxarifado.Data;
using SistemaAlmoxarifado.Models;

namespace SistemaAlmoxarifado.Services;

public class SolicitacaoService
{
    private readonly AppDbContext _context;

    public SolicitacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Solicitacao>> ObterTodasAsync()
    {
        return await _context.Solicitacoes
            .OrderByDescending(s => s.DataSolicitacao)
            .ToListAsync();
    }

    public async Task<List<Solicitacao>> ObterPorStatusAsync(StatusSolicitacao status)
    {
        return await _context.Solicitacoes
            .Where(s => s.Status == status)
            .OrderByDescending(s => s.DataSolicitacao)
            .ToListAsync();
    }

    public async Task<List<Solicitacao>> ObterPorSetorAsync(string setor)
    {
        return await _context.Solicitacoes
            .Where(s => s.Setor == setor)
            .OrderByDescending(s => s.DataSolicitacao)
            .ToListAsync();
    }

    public async Task<Solicitacao?> ObterPorIdAsync(int id)
    {
        return await _context.Solicitacoes.FindAsync(id);
    }

    public async Task<Solicitacao> CriarAsync(Solicitacao solicitacao)
    {
        solicitacao.DataSolicitacao = DateTime.Now;
        _context.Solicitacoes.Add(solicitacao);
        await _context.SaveChangesAsync();
        return solicitacao;
    }

    public async Task AtualizarAsync(Solicitacao solicitacao)
    {
        _context.Solicitacoes.Update(solicitacao);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarStatusAsync(int id, StatusSolicitacao novoStatus)
    {
        var solicitacao = await _context.Solicitacoes.FindAsync(id);
        if (solicitacao != null)
        {
            solicitacao.Status = novoStatus;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ExcluirAsync(int id)
    {
        var solicitacao = await _context.Solicitacoes.FindAsync(id);
        if (solicitacao != null)
        {
            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> ObterSetoresAsync()
    {
        return await _context.Solicitacoes
            .Select(s => s.Setor)
            .Distinct()
            .OrderBy(s => s)
            .ToListAsync();
    }
}
