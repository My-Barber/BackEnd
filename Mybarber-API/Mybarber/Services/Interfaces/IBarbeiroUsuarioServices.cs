﻿using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IBarbeiroUsuarioServices
    {
        Task<bool> DeleteUsuarioBarbeiro(Task<Barbeiros> barbeiro);
        Task<bool> CreateUsuarioBarbeiro(BarbeirosRequestDto barbeiroDto);
        
    }
}
