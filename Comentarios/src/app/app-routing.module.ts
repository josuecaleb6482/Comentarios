import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregarComentarioComponent } from './components/agregar-comentario/agregar-comentario.component';
import { ListarComentariosComponent } from './components/listar-comentarios/listar-comentarios.component';
import { VerComentarioComponent } from './components/ver-comentario/ver-comentario.component';

const routes: Routes = [
  {path: '', component: ListarComentariosComponent},
  {path: 'agregar', component: AgregarComentarioComponent},
  {path: 'editar/:id', component: AgregarComentarioComponent},
  {path: 'ver/:id', component: VerComentarioComponent},
  {path: '**', redirectTo: '', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
