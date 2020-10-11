import { Injectable } from '@nestjs/common';
import { Question } from 'src/entities/question.entity';

@Injectable()
export class QuizService {
  getQuestions(): Question[] {
    return [
      {
        title: 'BMW',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão']
      },
      {
        title: 'Toyota',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão']
      },
      {
        title: 'Mini',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão']
      },
      {
        title: 'General Motors',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão']
      },
      {
        title: 'Rolls-Royce',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão']
      },
    ]
  }
}
