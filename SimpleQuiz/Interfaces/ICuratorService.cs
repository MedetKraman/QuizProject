using SimpleQuiz.Models;
using SimpleQuiz.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleQuiz.Interfaces {
    public interface ICuratorService {
        Task<Guid> CreateAsync(CuratorDTO dto);
        Guid Create(CuratorDTO dto);

        Task<CuratorView> GetByIdAsync(Guid id);
        CuratorView GetById(Guid id);

        Task<List<CuratorView>> SearchByNameAsync(string searchText);
        List<CuratorView> SearchByName(string searchText);

        Task RemoveByIdAsync(Guid id);
        void RemoveById(Guid id);

        Task RemoveByIdsAsync(List<Guid> id);
        void RemoveByIds(List<Guid> id);
    }
}
