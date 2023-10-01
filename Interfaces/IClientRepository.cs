using back_end_alpha.Models;
namespace back_end_alpha.Interfaces
{
	public interface IClientRepository
	{
		ICollection<Client> GetClients();

		Client GetClientById(int ClientId);

		ICollection<Client> GetClientsByEmployeeId(int EmploeeId);


		bool CreateClient(String NationalIdentity,String FirstName, String LastName,String PhoneNumber,int state,String Note, int EmployeeId);

		bool DeleteClient(Client client);

		bool Save();

    }
}

