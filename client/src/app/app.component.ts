import {Component, OnInit} from '@angular/core';
import * as signalR from '@microsoft/signalr'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  time: string | undefined;

  ngOnInit() {
    let connection = new signalR.HubConnectionBuilder()
      .withUrl("http://127.0.0.1:5000/hub")
      .build();

    connection.on("send", (time:string) => {
      this.time = time;
    });

    connection.start()
      .then(()=> console.log("Connected."));
  }
}
