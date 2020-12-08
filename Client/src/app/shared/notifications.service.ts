import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import * as signalR from "@aspnet/signalr";
import { environment } from 'src/environments/environment';
import { IHttpConnectionOptions } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})

export class NotificationsService {
  private hubConnection!: signalR.HubConnection;

  constructor(private toastr: ToastrService) { }

  public subscribe = () => {
    const options = {
      accessTokenFactory: () => {
        return localStorage.getItem('token');
      },
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    };

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.notificationsUrl + 'notifications', options as IHttpConnectionOptions)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err: any) => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('ReceiveNotification', (data: any) => {
      console.log(data);
      this.toastr.success(`${data.title} ${data.price}!`, "Ad created");
    });
  }
}