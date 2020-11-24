import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataService } from 'src/app/data.service';
import { Router,  ActivatedRoute } from '@angular/router';
import { AngularFireAuth } from '@angular/fire/auth';
import { TodoListComponent } from 'src/app/components/todo-list/todo-list.component';



import { first } from 'rxjs/operators';


@Component({
  selector: 'app-details',
  templateUrl: './details.html',
  styleUrls: ['./details.css']
})
export class DetailComponent implements OnInit {
  public form: FormGroup;
  public todo : any;
  public user : String = "";
  public id : String;
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private service: DataService,
    private router: Router,
    private afAuth: AngularFireAuth,
    
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(x => {  
      this.id = x['id'];
    });

    this.afAuth.idToken.subscribe(token => {
      this.service.getTodoById(token, this.id)
            .subscribe((data: any) => this.todo = data);
    });


  }
}