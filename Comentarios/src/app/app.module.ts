import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ListarComentariosComponent } from './components/listar-comentarios/listar-comentarios.component';
import { VerComentarioComponent } from './components/ver-comentario/ver-comentario.component';
import { AgregarComentarioComponent } from './components/agregar-comentario/agregar-comentario.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListarComentariosComponent,
    VerComentarioComponent,
    AgregarComentarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
