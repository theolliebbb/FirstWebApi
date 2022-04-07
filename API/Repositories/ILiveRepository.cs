using System;
using API.Models;

namespace API.Repositories
{
	public interface ILiveRepository
	{
		Task<IEnumerable<Live>> Get();
		Task<Live> Get(int Id);
		Task<Live> Create(Live live);
		Task Update(Live live);
		Task Delete(int Id);
	}
}

