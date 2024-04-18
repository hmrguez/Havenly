import {Injectable} from '@angular/core';
import {Apollo, gql} from "apollo-angular";
import {Lease} from "./lease";


const CREATE_LEASE_FROM_SCRATCH_MUTATION = gql`
  mutation CreateLease($input: CreateLeaseTenantDtoInput!) {
    createFromScratch(dto: $input)
  }
`;


@Injectable({
  providedIn: 'root'
})
export class LeasesService {

  constructor(private apollo: Apollo) {
  }

  createFromScratch(dto: any) {
    return this.apollo.mutate({
      mutation: CREATE_LEASE_FROM_SCRATCH_MUTATION,
      variables: {
        input: dto
      }
    });
  }
}
