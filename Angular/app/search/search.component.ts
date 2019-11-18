import { Component, OnInit, Input, Output } from '@angular/core';
import { Client } from '../models/client.model';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  client = new Client();

  searchedResults = [];

OnSearchingClient(client: Client) {
this.clientService.OnSearchingClient(this.client).subscribe(response => {
    this.searchedResults = response;
  });

}


  constructor(private clientService: ClientService) { }

  ngOnInit() {
  }

}
