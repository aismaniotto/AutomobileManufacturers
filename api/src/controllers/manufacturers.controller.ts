import { Controller, Get } from '@nestjs/common';
import { Question } from 'src/entities/question.entity';
import { QuizService } from 'src/services/quiz.service';

@Controller()
export class ManufacturersController {
  constructor(private readonly quizService: QuizService) {}

  @Get()
  getHello(): Question[] {    
    return this.quizService.getQuestions();
  }
}
