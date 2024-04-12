using PasswordManager.Dto.Password;
using PasswordManager.Entities;
using PasswordManager.Repositories.DataAccess;

namespace PasswordManager.Services
{
    public class PasswordDataService(IPasswordRepository repository) : IPasswordDataService
    {
        private readonly IPasswordRepository _repository = repository;
        
        public int AddPassword(RequestAddPasswordDataDTO request) {
            var encrypted = EncodePassword(request.Password);

            var passwordData = new PasswordData
            {
                App = request.App,
                Category = request.Category,
                EncryptedPassword = encrypted,
                Username = request.Username,
            };

            _repository.Add(passwordData);
            return passwordData.Id;
        }

        public PasswordData? UpdatePasswordData(int id ,RequestAddPasswordDataDTO request){
            var data = _repository.GetPasswordDataById(id);
            
            if (data is null){
                return null;
            }

            var encryptedPassword = EncodePassword(request.Password);
            
            data.App = request.App;
            data.Category = request.Category;
            data.Username = request.Username;
            data.EncryptedPassword = encryptedPassword;

            _repository.Update(data);
            return data;
        }

        public bool DeletePasswordDataEntry(int id){
            var data = _repository.GetPasswordDataById(id);

            if(data is null){
                return false;
            }

            _repository.Delete(data);
            return true;
        }

        public PasswordData? GetEncryptedPasswordData(int id)=> _repository.GetPasswordDataById(id);

        public DecryptedPasswordData? GetDecryptedPasswordData(int id){
            var data = _repository.GetPasswordDataById(id);

            if (data is null) {
                return null;
            }

            var decryptedPassword = DecodePassword(data.EncryptedPassword);
            return new DecryptedPasswordData{
                Id= data.Id,
                App = data.App,
                Category = data.Category,
                Username = data.Username,
                DecryptedPassword = decryptedPassword
            };
        }


        private static string EncodePassword(string password){
            var bytes = System.Text.Encoding.ASCII.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        private static string DecodePassword(string encryptedPassword) {
            var encoded64Bytes = Convert.FromBase64String(encryptedPassword);
            return System.Text.Encoding.ASCII.GetString(encoded64Bytes);
        }

        public List<PasswordData> GetListOfAllPasswords()
        {
            return _repository.GetAllPasswords();
        }
    }
}