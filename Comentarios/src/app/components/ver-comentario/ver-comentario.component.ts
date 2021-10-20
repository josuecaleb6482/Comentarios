import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comentario } from 'src/app/interfaces/Comentario';
import { ComentarioService } from 'src/app/services/comentario.service';
import { faCalendar, faUser } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-ver-comentario',
  templateUrl: './ver-comentario.component.html',
  styleUrls: ['./ver-comentario.component.sass']
})
export class VerComentarioComponent implements OnInit {
  id: number;
  comentario: Comentario | undefined;
  calendar = faCalendar;
  usuario = faUser;

  constructor(private aRoute: ActivatedRoute,
              private _comentarioservice: ComentarioService) { 
    this.id = +this.aRoute.snapshot.paramMap.get("id")!;
  }

  ngOnInit(): void {
    this.getComentario();
  }

  getComentario(){
    this._comentarioservice.getComntario(this.id).subscribe(data =>{
      this.comentario = data;
    });
  }
}
