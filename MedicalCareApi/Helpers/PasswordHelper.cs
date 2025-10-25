namespace MedicalCareApi.Helpers
{
    public class PasswordHelper
    {
        // Hashes the plain-text password for storage in the database
        public static string HashPassword(string? password) // <-- Note the '?'
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verifies the entered password against the stored hash
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Compares the entered password against the hash
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
