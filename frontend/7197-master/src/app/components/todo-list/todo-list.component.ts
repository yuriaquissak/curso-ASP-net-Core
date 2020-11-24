import { Component, OnInit, Input } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { AngularFireAuth } from '@angular/fire/auth';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  @Input() todos: any = null;
  public user : String = "";

  constructor(
    private route: ActivatedRoute,
    private service: DataService,
    public afAuth: AngularFireAuth,
    private router: Router,
  ) { }

  ngOnInit(): void {
        this.afAuth.authState.subscribe( data =>  { 
          this.user = data.uid;   
          console.log(this.user); 
          } 
        );
        
  }

  Details(todo) {
    this.afAuth.idToken.subscribe(token => {
      this.service.getAllTodos(token).subscribe((data: any) => this.todos = data);
    });
  }

  markAsDone(todo) {
    this.afAuth.idToken.subscribe(token => {
      const data = { id: todo.id };
      this.service.markAsDone(data, token).subscribe(res => { todo.done = true });
    });
  }

  markAsUndone(todo) {
    this.afAuth.idToken.subscribe(token => {
      const data = { id: todo.id };
      this.service.markAsUndone(data, token).subscribe(res => { todo.done = false });
    });
  }

}
