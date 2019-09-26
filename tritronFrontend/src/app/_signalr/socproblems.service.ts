import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {environment} from '../../environments/environment';
import {Observable, Subject} from 'rxjs';

interface message {
}

@Injectable({
  providedIn: 'root'
})
export class SocproblemsService {

  private message$: Subject<message>;
  private connection: signalR.HubConnection;

  constructor() {
    this.message$ = new Subject<message>();
    this.connection = new signalR.HubConnectionBuilder()
        .withUrl(environment.socketurl+'problems', {
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets
        })
        .build();
  }
  public connect() {
    this.connection.start().catch(err => console.log(err));
    this.connection.on('SendMessage', (message) => {
      this.message$.next(message);
    });
  }
  public getMessage(){
    return this.connection;
  }
  public disconnect() {
    this.connection.stop();
  }
}
