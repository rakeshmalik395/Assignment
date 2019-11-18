// import { ClientAddresses } from './ClientAddress';
export class Client {
  ClientId: number;
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  clientAddresses: ClientAddresses[];


}
export class ClientAddresses  {
  id: number;
  ClientId: number;
  CityName: string;
}

