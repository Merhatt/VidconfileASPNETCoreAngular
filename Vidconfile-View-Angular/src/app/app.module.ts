import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { AngularFileUploaderModule } from 'angular-file-uploader';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './services/auth.service';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify.service';
import { appRoutes } from './routes';
import { EditProfileComponent } from 'src/app/edit-profile/edit-profile.component';
import { RouterService } from './services/router.service';
import { AuthGuard } from './guards/auth.guard';
import { VideoService } from './services/video.service';
import { VideoListComponent } from './video-list/video-list.component';
import { UploadVideoComponent } from './upload-video/upload-video.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent,
      EditProfileComponent,
      VideoListComponent,
      UploadVideoComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      AngularFileUploaderModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      RouterService,
      AuthGuard,
      VideoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
