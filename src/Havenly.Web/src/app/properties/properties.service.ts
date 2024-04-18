import {Injectable} from '@angular/core';
import {Apollo, gql} from "apollo-angular";

const getPropertiesByOwnerQuery = gql`
  query getPropertiesByOwner($ownerId: UUID!) {
    propertiesByOwner(ownerId: $ownerId) {
      id
      street
      city
      type
      zipCode
      country
      bedrooms
      bathrooms
      squareFootage
      price
      ownerId
    }
  }
`;

@Injectable({
  providedIn: 'root'
})
export class PropertiesService {

  constructor(private apollo: Apollo) {
  }

  getPropertiesByOwner(ownerId: string) {
    return this.apollo.watchQuery<any>({
      query: getPropertiesByOwnerQuery,
      variables: {
        ownerId
      }
    }).valueChanges;
  }
}
