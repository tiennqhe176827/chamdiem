--SELECT * FROM subjecttable;
--SELECT * FROM class;
--SELECT * FROM teacher;
--SELECT * FROM teacher_subject;
--SELECT * FROM titlecode;
--SELECT * FROM answer;

select * from teacher_subject
join subjecttable on teacher_subject.subjectid=subjecttable.subjectid
join titlecode on titlecode.teacher_subject_id=teacher_subject.id
join class on class.classid=titlecode.classid
where teacherid=2
--chỉ cần lấy ra subjectname classname titlecodenumber và titlecodeid