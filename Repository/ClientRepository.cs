using back_end_alpha.Data;
using back_end_alpha.Dto;
using back_end_alpha.Interfaces;
using back_end_alpha.Models;

namespace back_end_alpha.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
		}

        public bool CreateClient(string NationalIdentity, string FirstName, string LastName, string PhoneNumber, int state, string Note, int EmployeeId)
        {
            var clinet = new Client()
            {
                NationalIdentity = NationalIdentity,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                State = state,
                Note = Note,
                EmployeeId = EmployeeId

            };

            _context.Add(clinet);

            return Save();
        }

        public bool DeleteClient(Client client)
        {
            client.State = -1;
            _context.Update(client);

            return Save();
        }

        public Client GetClientById(int ClientId)
        {
            return _context.Clients.Where(C => C.Id == ClientId).FirstOrDefault();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(C => C.Id).ToList();
        }

        public ICollection<Client> GetClientsByEmployeeId(int EmploeeId)
        {
            return _context.Clients.Where(C => C.EmployeeId == EmploeeId).ToList();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }
    }
}

