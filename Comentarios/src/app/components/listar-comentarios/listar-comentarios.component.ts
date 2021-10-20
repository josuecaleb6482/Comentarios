import { Component, OnInit } from '@angular/core';
import { Comentario } from 'src/app/interfaces/Comentario';
import { ComentarioService } from 'src/app/services/comentario.service';

@Component({
  selector: 'app-listar-comentarios',
  templateUrl: './listar-comentarios.component.html',
  styleUrls: ['./listar-comentarios.component.sass']
})
export class ListarComentariosComponent implements OnInit {

  listComentario: Comentario[] = [
  ]

  constructor(private _comentrioService: ComentarioService) { }

  ngOnInit(): void {
    this.getComentarios();
  }

  getComentarios(){
    this._comentrioService.getListComentarios().subscribe(data =>{
      this.listComentario = data
    }, error =>{
      console.log(error());      
    });
  }

  eliminarcomentario(id:any){
    this._comentrioService.deletecomentario(id).subscribe(data =>{
      this.getComentarios();
    },error =>{
      console.log(error);
    });
  }
}
