import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FilmesDetail } from '../shared/filmes-detail.model';
import { FilmesDetailService } from '../shared/filmes-detail.service';

@Component({
  selector: 'app-filmes-details',
  templateUrl: './filmes-details.component.html',
  styleUrls: ['./filmes-details.component.scss']
})
export class FilmesDetailsComponent implements OnInit {

  constructor(public service : FilmesDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(selecterRecord:FilmesDetail){
    this.service.data = Object.assign({},selecterRecord);
  }
  onDelete(id:number){
    if(confirm("Apagar dado?")){
    this.service.deleteFilmeDetail(id).subscribe(
      res=>{
        this.service.deleteFilmeDetail(id)
        this.service.refreshList()
        this.toastr.success('Apagado com sucesso.', 'Filme')
      }
    )
    }
  }
}
