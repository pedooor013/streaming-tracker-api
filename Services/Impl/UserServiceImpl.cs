using StreamingSubscriptionTrackerAPI.DTOs;
using StreamingSubscriptionTrackerAPI.Models;
using StreamingSubscriptionTrackerAPI.Models.Context;

namespace StreamingSubscriptionTrackerAPI.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private MSSQLContext _context;

        public UserServiceImpl(MSSQLContext context)
        {
            _context = context;
        }

        //GET
        public List<UserResponseDTO> GetAll() =>
            _context.Users
                .Select(u => ToResponseDTO(u))
                .ToList();

        public List<UserResponseDTO> GetByActived(bool actived)
        {
            return _context.Users
                .Where(u => u.Actived == actived)
                .Select(u => ToResponseDTO(u))
                .ToList();
        }

        public UserResponseDTO GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) throw new ArgumentException($"User with email {email} not found.");
            return ToResponseDTO(user);
        }

        public UserResponseDTO GetById(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) throw new ArgumentException($"User with ID {id} not found.");
            return ToResponseDTO(user);
        }

        public UserResponseDTO GetByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) throw new ArgumentException($"User with username {username} not found.");
            return ToResponseDTO(user);
        }

        //POST
        public UserResponseDTO Create(UserRequestDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Name,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Actived = userDto.Actived
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            
            return ToResponseDTO(user);
        }

        //PUT
        public UserResponseDTO Update(long id, UserRequestDTO userDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null) throw new ArgumentException($"User with ID {id} not found.");
            
            existingUser.Username = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.Actived = userDto.Actived;

            _context.SaveChanges();
            return ToResponseDTO(existingUser);
        }

        public UserResponseDTO UpdateActived(long id, bool actived)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) throw new ArgumentException($"User with ID {id} not found.");

            existingUser.Actived = actived;
            _context.SaveChanges();
            return ToResponseDTO(existingUser);
        }

        public UserResponseDTO UpdatePassword(long id, string password)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) throw new ArgumentException($"User with ID {id} not found.");
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(password);
            _context.SaveChanges();
            return ToResponseDTO(existingUser);
        }

        //DELETE
        public UserResponseDTO Delete(long id)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) throw new ArgumentException($"User with ID {id} not found.");
            _context.Users.Remove(existingUser);
            _context.SaveChanges();
            return ToResponseDTO(existingUser);
        }

        //DTO UTILS
        private UserResponseDTO ToResponseDTO(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Actived = user.Actived
            };
        }
    }
}