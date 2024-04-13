export class RegisterRequestInput {
  constructor(email: string, password: string, username: string, contactInfo: string) {
    this.email = email;
    this.password = password;
    this.username = username;
    this.contactInfo = contactInfo;
  }

  email!: string;
  password!: string;
  username!: string;
  contactInfo!: string;
}

// public record RegisterRequest(string Username, string Email, string Password, string ContactInfo);
