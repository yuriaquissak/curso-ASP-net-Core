import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataService } from 'src/app/data.service';
import { Router,  ActivatedRoute } from '@angular/router';
import { AngularFireAuth } from '@angular/fire/auth';
import { TodoListComponent } from 'src/app/components/todo-list/todo-list.component';



import { first } from 'rxjs/operators';


@Component({
  selector: 'app-update',
  templateUrl: './update.html',
  styleUrls: ['./update.css']
})
export class UpdateComponent implements OnInit {
  public form: FormGroup;
  public todo : any = null;
  public user : String = "";
  public id : string = "";
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private service: DataService,
    private router: Router,
    private afAuth: AngularFireAuth
  ) {
    this.form = this.fb.group({
      title: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(60),
        Validators.required,
      ])],
      desc: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(300),
        Validators.required,
      ])],
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(x => {  
      this.id = x['id'];
    });

    } 

  


  submit() {
    this.afAuth.idToken.subscribe(token => {
      
      this.service.updateTodo(this.form.value, token, this.id)
        .subscribe(res => {
          this.router.navigateByUrl("/");
        });
    });
  }

}