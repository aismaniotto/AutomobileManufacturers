import { Module } from '@nestjs/common';
import { ManufacturersController } from './controllers/manufacturers.controller';
import { QuizService } from './services/quiz.service';

@Module({
  imports: [],
  controllers: [ManufacturersController],
  providers: [QuizService],
})
export class AppModule {}
