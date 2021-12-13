namespace PalindromeSagasMVC.Models
{
    public class Palindrome
    {
        public string InputWord { get; set; } = null!;
        public string RevWord { get; set; } = null!;
        public bool IsPalindrome { get; set; }

        public string Message { get; set; } = null!;

    }
}
