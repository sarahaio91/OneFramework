namespace Domain.Dtos.Account
{
    public class SignInResultDto
    {
        //
        // Summary:
        //     Returns a flag indication whether the sign-in was successful.
        public bool Succeeded { get; protected set; }
        //
        // Summary:
        //     Returns a flag indication whether the user attempting to sign-in is locked out.
        public bool IsLockedOut { get; protected set; }
        //
        // Summary:
        //     Returns a flag indication whether the user attempting to sign-in is not allowed
        //     to sign-in.
        public bool IsNotAllowed { get; protected set; }
        //
        // Summary:
        //     Returns a flag indication whether the user attempting to sign-in requires two
        //     factor authentication.
        public bool RequiresTwoFactor { get; protected set; }
    }
}
