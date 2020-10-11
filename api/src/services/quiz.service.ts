import { Injectable } from '@nestjs/common';
import { Answer } from 'src/entities/anwer.entity';
import { Question } from 'src/entities/question.entity';

@Injectable()
export class QuizService {
  getQuestions(): Question[] {
    return [
      {
        title: 'BMW',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão'],
      },
      {
        title: 'Toyota',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão'],
      },
      {
        title: 'Mini',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão'],
      },
      {
        title: 'General Motors',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão'],
      },
      {
        title: 'Rolls-Royce',
        options: ['Inglaterra', 'USA', 'Alemanha', 'Japão'],
      },
    ];
  }

  getAnswers(): Answer[] {
    return [
      {
        title: 'BMW',
        choice: 'Alemanha',
      },
      {
        title: 'Toyota',
        choice: 'Japão',
      },
      {
        title: 'Mini',
        choice: 'Inglaterra',
      },
      {
        title: 'General Motors',
        choice: 'USA',
      },
      {
        title: 'Rolls-Royce',
        choice: 'Inglaterra',
      },
    ];
  }

  calculateResult(answers: Answer[]): number {
    const answersKey = this.getAnswers();
    let result = 0;

    answersKey.forEach(key => {
      const answer = answers.find(answer => answer.title == key.title);
      if (answer.choice === key.choice) {
        result++;
      }
    });
    return result / answersKey.length;
  }
}
