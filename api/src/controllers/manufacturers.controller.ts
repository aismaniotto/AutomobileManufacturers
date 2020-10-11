import { Body, Controller, Get, Post } from '@nestjs/common';
import { Answer } from 'src/entities/anwer.entity';
import { Question } from 'src/entities/question.entity';
import { QuizService } from 'src/services/quiz.service';

@Controller('/quiz')
export class ManufacturersController {
  constructor(private readonly quizService: QuizService) {}

  @Get()
  getAction(): Question[] {
    return this.quizService.getQuestions();
  }

  @Post()
  postAction(@Body() answers: Answer[]): any {
    return this.quizService.calculateResult(answers);
  }
}
