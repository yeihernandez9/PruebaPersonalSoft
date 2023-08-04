using System;
namespace PruebaPersonalSoft.Repositories.Polizas
{
	public interface IPolizaCollection
	{
		Task IserttPoliza(Models.Poliza poliza);

		Task UpdatePoliza(Models.Poliza poliza);

		Task DeletePoliza(string id);

		Task<List<Models.Poliza>> GetAllPoliza();

		Task<Models.Poliza> GetPolizaById(string id);
	}
}

