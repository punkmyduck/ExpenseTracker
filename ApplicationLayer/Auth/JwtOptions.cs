namespace ExpenseTracker.ApplicationLayer.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "MyApp";
        public string Audience { get; set; } = "MyAppUser";
        public string Key { get; set; } = "!89ugsaUBFDSO9)h1j2lFD(A&BjbfGAKDgnLBJBGDASBGUOU#O4OUDSBUV(#IdfnOUDnfdz(F*#29"; // HMAC_SECRET
        public int AccessTokenLifetimeMinutes { get; set; } = 15;
        public int RefreshTokenLifetimeDays { get; set; } = 7;
    }
}
