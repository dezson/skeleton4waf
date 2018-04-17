using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EducationSystem.DataAccess.Models;

namespace EducationSystem.Web.Models
{
    public class AccountService : IAccountService
    {
        private readonly EducationSystemContext _context;

        public AccountService(EducationSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Vendégadatok lekérdezése.
        /// </summary>
        /// <param name="userName">A felhasználónév.</param>
        public Student GetSudent(String studentName)
        {
            if (studentName == null)
                return null;

            //return _context.Guests.FirstOrDefault(c => c.UserName == userName); // megkeressük a vendéget
            //return _context.Student.FirstOrDefault(c => c.UserName == userName);
            //Fime: !!!!
            return null;
        }

        /// <summary>
        /// Felhasználó bejelentkeztetése.
        /// </summary>
        /// <param name="user">A felhasználó nézetmodellje.</param>
        public Boolean Login(LoginViewModel user)
        {
            if (user == null)
                return false;

            // ellenőrizzük az annotációkat
            if (!Validator.TryValidateObject(user, new ValidationContext(user, null, null), null))
                return false;

            //Guest guest = _context.Guests.FirstOrDefault(c => c.UserName == user.UserName); // megkeressük a felhasználót
            Student student = _context.Student.Where(x => x.StudentName == user.UserName).FirstOrDefault();

            if (student == null)
                return false;


            // ellenőrizzük a jelszót (ehhez a kapott jelszót hash-eljük)
            //Byte[] passwordBytes = null;
            //using (SHA512CryptoServiceProvider provider = new SHA512CryptoServiceProvider())
            //{
            //    passwordBytes = provider.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
            //}

            //Byte[] passwordBytes_student = Encoding.UTF8.GetBytes(student.Password);
            //String strben = Encoding.Unicode.GetString(passwordBytes);
            //if (!passwordBytes.ToString().SequenceEqual(student.Password))
            if (!String.Equals(user.UserPassword, student.Password))
                return false;

            return true;
        }

        /// <summary>
        /// Felhasználó kijelentkeztetése.
        /// </summary>
        public Boolean Logout()
        {
            return true;
        }

        /// <summary>
        /// Vendég regisztrációja.
        /// </summary>
        /// <param name="guest">A vendég nézetmodellje.</param>
        public Boolean Register(RegistrationViewModel guest)
        {
            if (guest == null)
                return false;

            // ellenőrizzük az annotációkat
            if (!Validator.TryValidateObject(guest, new ValidationContext(guest, null, null), null))
                return false;

            //Fixme: StudentName would be StudentUser.
            if (_context.Student.Count(c => c.StudentName == guest.UserName) != 0)
                return false;

            // kódoljuk a jelszót
            Byte[] passwordBytes = null;
            using (SHA512CryptoServiceProvider provider = new SHA512CryptoServiceProvider())
            {
                passwordBytes = provider.ComputeHash(Encoding.UTF8.GetBytes(guest.UserPassword));
            }


            // elmentjük a felhasználó adatait
            _context.Student.Add(new Student
            {
                StudentName = guest.UserName,
                Password = System.Text.Encoding.UTF8.GetString(passwordBytes),
            });
    
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Vendég létrehozása (regisztráció nélkül).
        /// </summary>
        /// <param name="guest">A vendég nézetmodellje.</param>
        /// <param name="userName">A felhasznalónév.</param>
        public Boolean Create(StudentViewModel guest, out String userName)
        {
            userName = "user" + Guid.NewGuid(); // a felhasználónevet generáljuk

            if (guest == null)
                return false;

            // ellenőrizzük az annotációkat
            if (!Validator.TryValidateObject(guest, new ValidationContext(guest, null, null), null))
                return false;

            // elmentjük a felhasználó adatait
            _context.Student.Add(new Student
            {
                 StudentName = userName,
            });

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
