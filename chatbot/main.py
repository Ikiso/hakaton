import joblib
from gensim.utils import simple_preprocess

class Neural:
    def decoder(self, pred):
        if pred == '__label__0':
            return 'Справка'
        if pred == '__label__1':
            return 'Поиск_курса'
        if pred == '__label__2':
            return 'Поиск_по_курсу'
        if pred == '__label__3':
            return 'Задолжности'
        if pred == '__label__4':
            return 'Новое_за_период'


    def predict(self, string, decode):

        string = ' '.join(simple_preprocess(string))
        filename1 = "my_model.joblib" # путь до модели 
        filename2 = "vectorizer.joblib" # путь до векторизатора

        loaded_model = joblib.load(filename1) # модель
        loaded_vect = joblib.load(filename2) # векторизатор

        pred =  loaded_model.predict(loaded_vect.transform([string]))

        if decode: # второй аргумент в функции, переводит в читаемый формат при True, возвращает id при False
            return self.decoder(pred[0])
        else:
            return pred[0][-1]
