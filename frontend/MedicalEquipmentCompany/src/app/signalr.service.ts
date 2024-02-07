// signalr.service.ts

import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  private messageSubject = new Subject<string>();
  public message$ = this.messageSubject.asObservable();

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44333/messageHub',{
/*         skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets */
      })
      .build();

    this.hubConnection.on('ReceiveMessage', (message: string) => {
      this.messageSubject.next(message);
    });

    this.hubConnection.start().then(() => {
      console.log('SignalR connected');
    });
  }
}
