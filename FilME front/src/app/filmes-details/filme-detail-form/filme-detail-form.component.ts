import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FilmesDetail } from 'src/app/shared/filmes-detail.model';
import { FilmesDetailService } from 'src/app/shared/filmes-detail.service';

@Component({
  selector: 'app-filme-detail-form',
  templateUrl: './filme-detail-form.component.html',
  styleUrls: ['./filme-detail-form.component.scss']
})
export class FilmeDetailFormComponent implements OnInit {

  constructor(public service:FilmesDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }
  onSubmit(form:NgForm){
      this.addOp(form); 
  }
  
  addOp(form:NgForm){
    this.service.postFilmeDetail().subscribe(
      res=>{
        this.reset(form)
        this.service.refreshList()
        this.toastr.success('Adicionado com sucesso.', 'Filme')
      }
      );
  }
  updateOp(form:NgForm){
    this.service.putFilmeDetail().subscribe(
      res=>{
        this.reset(form)
        this.service.refreshList()
        this.toastr.info('Alterado com sucesso.', 'Filme')
      }
      );
  }
  reset(form:NgForm){
    form.form.reset();
    this.service.data = new FilmesDetail();
  }
}
