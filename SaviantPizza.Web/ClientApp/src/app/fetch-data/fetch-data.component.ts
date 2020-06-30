//import { Component, Inject } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

//@Component({
//  selector: 'app-fetch-data',
//  templateUrl: './fetch-data.component.html'
//})
//export class FetchDataComponent {
//  public forecasts: WeatherForecast[];



//  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//    let url = baseUrl + 'Pizza';
//    alert(url);
//    http.get<WeatherForecast[]>(baseUrl + 'Pizza').subscribe(result => {
//      this.forecasts = result;
//    }
//    //const body = { EmailId: 'a@b.com', Password : 'password' }
//    //http.post<any>(baseUrl + 'Login', body).subscribe(result => {
//    //  this.forecasts = result;
//    //}
//    , error => console.error(error));
//  } 
//}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}



import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
//import { AlertService } from '../_services/alert.service';


@Component({ templateUrl: 'fetch-data.component.html' })
export class FetchDataComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    //private alertService: AlertService
  ) {
    // redirect to home if already logged in
    //if (this.authenticationService.currentUserValue) {
    //  this.router.navigate(['/']);
    //}
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    //this.alertService.clear();

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    alert("in fetch data");
    this.loading = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value)
      //.pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
         // this.alertService.error(error);
          this.loading = false;
        });
  }
}



