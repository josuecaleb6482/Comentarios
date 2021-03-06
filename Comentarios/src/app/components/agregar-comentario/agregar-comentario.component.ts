import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Comentario } from 'src/app/interfaces/Comentario';
import { ComentarioService } from 'src/app/services/comentario.service';
@Component({
  selector: 'app-agregar-comentario',
  templateUrl: './agregar-comentario.component.html',
  styleUrls: ['./agregar-comentario.component.sass']
})
export class AgregarComentarioComponent implements OnInit {

  agregarComentario: FormGroup;
  accion = "Agregar";
  id = 0;
  comentario: Comentario | undefined

  constructor(private fb: FormBuilder,
              private _comentarioService: ComentarioService,
              private router: Router,
              private aRoute: ActivatedRoute) { 
    this.agregarComentario = this.fb.group({
        titulo: ['', Validators.required],
        creador: ['', Validators.required],
        texto: ['', Validators.required]
      })
      this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.esEditar()
  }

  esEditar() {
    if(this.id != 0){
      this.accion = "Editar";
      this._comentarioService.getComntario(this.id).subscribe(data=>{
        this.comentario = data
        this.agregarComentario.patchValue({
          titulo: data.titulo,
          creador: data.creador,
          texto: data.texto,
          fechaCreacion: data.fechaCreacion
        })
      },error =>{
        console.log('error');        
      })
    }
  }

  agregarEditaComentario()
  {
    if(this.comentario == undefined)
    {
      const comentario: Comentario ={
      titulo: this.agregarComentario.get('titulo')?.value,
      creador: this.agregarComentario.get('creador')?.value,
      texto: this.agregarComentario.get('texto')?.value,
      fechaCreacion: new Date
      }
      this._comentarioService.saveComentario(comentario).subscribe(data =>{
        this.router.navigate(['/']);
      }),console.error();
    }else{
      const comentario: Comentario ={
        id: this.comentario.id,
        titulo: this.agregarComentario.get('titulo')?.value,
        creador: this.agregarComentario.get('creador')?.value,
        texto: this.agregarComentario.get('texto')?.value,
        fechaCreacion: this.comentario.fechaCreacion,
      }
      this._comentarioService.editComentario(this.id,comentario).subscribe(data=>{
        this.router.navigate(['/']);
      },error=>{
        console.log("error");
      })
    }
  }
}
