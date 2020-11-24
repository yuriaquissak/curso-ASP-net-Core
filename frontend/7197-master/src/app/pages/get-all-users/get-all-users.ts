import { Component, OnInit, Input } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { AngularFireAuth } from '@angular/fire/auth';

@Component({
  selector: 'app-get-all-users',
  templateUrl: './get-all-users.html',
  styleUrls: ['./get-all-users.css']
})
export class AllUsersComponent implements OnInit {
  public todos: any[] = null;

  constructor(
    private service: DataService,
    private afAuth: AngularFireAuth,
  ) { }

  ngOnInit(): void {
    this.afAuth.idToken.subscribe(token => {
      this.service.getAllUsers(token).subscribe((data: any) => this.todos = data);
    });
  }

}
