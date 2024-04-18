import {Apollo, gql} from 'apollo-angular';
import {Injectable} from "@angular/core";
import {tap} from "rxjs";
import {LoginRequestInput} from "./loginRequestInput";
import {RegisterRequestInput} from "./registerRequestInput";
import {Router} from "@angular/router";
import {JwtHelperService} from '@auth0/angular-jwt';

const LOGIN_MUTATION = gql`
  mutation Login($input: LoginRequestInput!) {
    login(input: $input) {
      token
    }
  }
`;

const REGISTER_MUTATION = gql`
  mutation Register($input: RegisterRequestInput!) {
    register(input: $input) {
      token
    }
  }
`;

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private apollo: Apollo, private router: Router, private jwtHelper: JwtHelperService) {
  }

  public get loggedIn(): boolean {
    const token = localStorage.getItem('access_token');
    if (!token) {
      return false;
    }

    return !this.jwtHelper.isTokenExpired(token);
  }

  public get isOwner(): boolean {
    const token = localStorage.getItem('access_token');
    if (!token) {
      return false;
    }

    const decodedToken: any = this.jwtHelper.decodeToken(token);
    return decodedToken.isOwner;
  }

  public get ownerId(): string{
    const token = localStorage.getItem('access_token');
    if (!token) {
      return '';
    }

    const decodedToken: any = this.jwtHelper.decodeToken(token);
    return decodedToken.ownerId;
  }

  login(username: string, password: string) {
    return this.apollo.mutate({
      mutation: LOGIN_MUTATION,
      variables: {
        input: new LoginRequestInput(username, password)
      }
    }).pipe(
      tap({
        next: (result: any) => {
          console.log(result)
          localStorage.setItem('access_token', result.data.login.token);
        },
        error: (error: any) => {
          console.log('Error:', error);
        }
      })
    );
  }

  register(username: string, email: string, password: string, contactInfo: string) {
    return this.apollo.mutate({
      mutation: REGISTER_MUTATION,
      variables: {
        input: new RegisterRequestInput(email, password, username, contactInfo)
      }
    }).pipe(
      tap({
        next: (result: any) => {
          console.log(result)
          localStorage.setItem('access_token', result.data.register.token);
        },
        error: (error: any) => {
          console.log('Error:', error);
        },
      })
    );
  }

  logout() {
    localStorage.removeItem('access_token');
    this.router.navigate(['/login']).then()
  }
}
