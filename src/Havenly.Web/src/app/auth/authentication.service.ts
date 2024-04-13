// authentication.service.ts
import {Apollo, gql} from 'apollo-angular';
import {Injectable} from "@angular/core";
import {tap} from "rxjs";
import {LoginRequestInput} from "./loginRequestInput";
import {RegisterRequestInput} from "./registerRequestInput";

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

  constructor(private apollo: Apollo) {
  }

  public get loggedIn(): boolean {
    return localStorage.getItem('access_token') !== null;
  }

  login(username: string, password: string) {
    this.apollo.mutate({
      mutation: LOGIN_MUTATION,
      variables: {
        input: new LoginRequestInput(username, password)
      }
    }).pipe(
      tap({
        next: (result: any) => {
          localStorage.setItem('access_token', result.data.login.token);
        },
        error: (error: any) => {
          console.log('Error:', error);
        }
      })
    ).subscribe();
  }

  register(username: string, email: string, password: string, contactInfo: string) {
    this.apollo.mutate({
      mutation: REGISTER_MUTATION,
      variables: {
        input: new RegisterRequestInput(email, password, username, contactInfo)
      }
    }).pipe(
      tap({
        next: (result: any) => {
          localStorage.setItem('access_token', result.data.register.token);
        },
        error: (error: any) => {
          console.log('Error:', error);
        }
      })
    ).subscribe();
  }

  logout() {
    localStorage.removeItem('access_token');
  }
}
