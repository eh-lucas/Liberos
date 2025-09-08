import { Component, signal, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient, provideHttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule], // apenas o necessário
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App implements OnInit {

  protected readonly title = signal('LiberosClient');

  books: any[] = [];
  loading = false;
  error = '';

  private http = inject(HttpClient);

  ngOnInit(): void {
    this.fetchBooks();
  }

  fetchBooks(): void {
    this.loading = true;
    this.http.get<any[]>('http://localhost:7170/Book/')
      .subscribe({
        next: data => {
          this.books = data;
          this.loading = false;
        },
        error: err => {
          console.error(err);
          this.error = 'Erro ao carregar livros';
          this.loading = false;
        }
      });
  }
}