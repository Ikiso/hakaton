FROM python:3.9-slim-buster
WORKDIR /app
COPY ./chatbot/requirements.txt /app
RUN pip install -r requirements.txt
COPY ./chatbot .
EXPOSE 5000
ENV FLASK_APP=wsgi.py
CMD ["flask", "run", "--host", "0.0.0.0"]